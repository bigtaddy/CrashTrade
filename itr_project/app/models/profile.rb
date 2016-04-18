# == Schema Information
#
# Table name: profiles
#
#  id         :integer          not null, primary key
#  avatar     :string(255)
#  user_id    :integer
#  created_at :datetime         not null
#  updated_at :datetime         not null
#  name       :string(254)
#  city       :string(255)
#  language   :string(255)
#  about      :string(255)
#

class Profile < ActiveRecord::Base
  belongs_to :user, :dependent => :destroy
  mount_uploader :avatar, AvatarUploader
  validates :about, :length => { :maximum => 255 }

  attr_accessible :avatar, :name, :city, :language, :about
end
