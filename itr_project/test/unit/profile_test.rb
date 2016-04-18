# == Schema Information
#
# Table name: profiles
#
#  id         :integer          not null, primary key
#  avatar     :string(255)
#  user_id    :integer
#  created_at :datetime         not null
#  updated_at :datetime         not null
#  name       :string(255)
#  city       :string(255)
#  language   :string(255)
#  about      :string(255)
#

require 'test_helper'

class ProfileTest < ActiveSupport::TestCase
  # test "the truth" do
  #   assert true
  # end
end
