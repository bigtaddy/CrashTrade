# == Schema Information
#
# Table name: tasks
#
#  id         :integer          primary key
#  title      :string(255)
#  content    :text
#  user_id    :integer
#  created_at :datetime
#  updated_at :datetime
#

class Task < ActiveRecord::Base
  after_create :reindex!
  after_update :reindex!
  validates :content, :presence => true, :length => { :minimum => 5, :maximum => 1000 }
  validates :title, :presence => true, :length => { :maximum => 20 }
  validates :creator, :presence => true
  acts_as_voteable
  belongs_to :creator, :class_name => "User", :foreign_key => :user_id
  acts_as_taggable_on :tags, :answers
  attr_accessible :title, :content, :tag_list, :answer_list
  has_many :user_tasks, :dependent => :destroy
  has_many :passed_users, :through => :user_tasks, :class_name => "User", :source => :user


  searchable do
    text :title, :content
  end


  protected
 
    def reindex!
      Sunspot.index!(self)
    end
end
